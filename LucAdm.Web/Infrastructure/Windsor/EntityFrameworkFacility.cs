﻿using System.Data.Entity;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace LucAdm.Web
{
    public class EntityFrameworkFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<PersistenceContext, DbContext>().ImplementedBy<PersistenceContext>().LifestylePerWebRequest());
        }
    }
}