using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.AutoCarryDecorator
{
    public abstract class CharacterDecorator : IAutoCarryCharacter
    {
        protected IAutoCarryCharacter _autoCarryCharacter;

        internal CharacterDecorator(IAutoCarryCharacter autoCarryCharacter)
        {
            _autoCarryCharacter = autoCarryCharacter 
                ?? throw new ArgumentException(nameof(autoCarryCharacter));
        }

        public virtual IAutoCarryCharacter ImbalancedSektor() => _autoCarryCharacter.ImbalancedSektor();
    }
}
