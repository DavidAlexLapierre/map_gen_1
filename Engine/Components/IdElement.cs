using System;
namespace ProjectEthereal.Engine.Components {
    abstract class IdElement {
        public Guid Id { get; private set; }
        public IdElement() {
            Id = Guid.NewGuid();
        }
    }
}
