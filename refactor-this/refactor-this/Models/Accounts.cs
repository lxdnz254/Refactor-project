using System;

namespace refactor_this.Models
{
    public class Account
    {
        private bool _isNew;

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public float Amount { get; set; }

        public Account()
        {
            _isNew = true;
        }

        public Account(Guid id)
        {
            _isNew = false;
            Id = id;
        }

        public bool IsNew()
        {
            return _isNew;
        }
    }
}