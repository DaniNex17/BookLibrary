﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Entity.Models
{
    [Table("RolesPermissions", Schema = "Security")]
    public class RolePermissionEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RoleEntity")]
        public int IdRol { get; set; }

        public RoleEntity RoleEntity { get; set; }

        [ForeignKey("PermissionEntity")]
        public int IdPermission { get; set; }

        public PermissionEntity PermissionEntity { get; set; }
    }
}
