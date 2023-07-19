﻿using Infraestructure.Entity.Models;
using Infraestructure.UnitOfWork.Interface;
using Library.Domain.Dto.Role;
using Library.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public RoleServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public List<GetRoleDto> GetAll()
        {
            IEnumerable<RoleEntity> roleQuery = _unitOfWork.RoleRepository.GetAll();
            //.FindAll(x=> & | ) para separar las condiciones


            List<GetRoleDto> roles = roleQuery.Select(x => new GetRoleDto()
            {
                Id = x.Id,
                Descripcion = x.Description
            })
            .ToList();

            return roles;

        }
    }
}
