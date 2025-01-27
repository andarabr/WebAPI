﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Base;
using DataAccess.ViewModels;

namespace DataAccess.Models
{
    [Table("TB_M_Application")]
    public class Application : BaseModel
    {
        public Application() { }

        public Application(ApplicationVM applicationVM)
        {
            this.Name = applicationVM.Name;
            this.CreateDate = DateTime.Now.ToLocalTime();
        }

        public void Update(ApplicationVM applicationVM)
        {
            this.Name = applicationVM.Name;
            this.UpdateDate = DateTime.Now.ToLocalTime();
        }

        public void Delete()
        {
            this.IsDeleted = true;
            this.DeleteDate = DateTime.Now.ToLocalTime();
        }

        public string Name { get; set; }
    }
}