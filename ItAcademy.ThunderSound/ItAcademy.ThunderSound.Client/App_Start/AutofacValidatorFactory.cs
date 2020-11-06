using System;
using System.Web.Mvc;
using FluentValidation;

namespace ItAcademy.ThunderSound.Client.App_Start
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IDependencyResolver dependencyResolver;

        public AutofacValidatorFactory(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return dependencyResolver.GetService(validatorType) as IValidator;
        }
    }
}