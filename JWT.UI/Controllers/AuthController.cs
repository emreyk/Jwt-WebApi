using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jwt.DataAccess.Interfaces;
using JWT.Business.Interfaces;
using JWT.Business.StringInfos;
using JWT.Business.ValidationRules.FluentValidation;
using JWT.Entities.Concrate;
using JWT.Entities.Dtos.AppUserDtos;
using JWT.Entities.Token;
using JWT.UI.CustomFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _appUserService = appUserService;
        }

        
        

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
            else
            {
                if (await _appUserService.CheckPasswordAsync(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRolesByUserNameAsync(appUserLoginDto.UserName);
                    var token = _jwtService.GenerateJwt(appUser, roles);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.Token = token;
                    return Created("", jwtAccessToken);
                }
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto, [FromServices] IAppUserRoleService appUserRoleService, [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserAddDto.UserName);
            if (appUser != null)
                return BadRequest($"{appUserAddDto.UserName} zaten alınmış");

            await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByUserNameAsync(appUserAddDto.UserName);
            var role = await appRoleService.FindByNameAsync(RoleInfo.Member);

            await appUserRoleService.AddAsync(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            return Created("", appUserAddDto);
        }
    }
}
