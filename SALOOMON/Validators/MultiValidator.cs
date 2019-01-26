using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace GatewayService.Validators
{
    public static class MultiValidator<T>
    {
        private static readonly List<IValidator<T>> Validators;

        static MultiValidator()
        {
            if (Validators == null)
            {
                Validators = new List<IValidator<T>>();
            }

            if (Validators.Any()) return;
            foreach (var validator in MultiValidatorBase.Validators)
            {
                var type = validator.MakeGenericType(typeof(T));
                var instance = Activator.CreateInstance(type);
                Validators.Add((IValidator<T>)instance);
            }
        }

        public static async Task<bool> IsValid(T message)
        {
            var result = true;
            foreach (var validator in Validators)
            {
                if (!await validator.IsValid(message))
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
