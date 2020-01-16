using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Data
{
    public class FingerPrintEntityBase : EntityBase
    {
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set
            {
                _CreatedBy = value ?? throw new ArgumentNullException(nameof(CreatedBy));
            }
        }
        private string _CreatedBy = string.Empty;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set 
            {
                if (value == null) throw new ArgumentNullException(nameof(CreatedOn));
                _CreatedOn = value;
            }
        }
        private DateTime _CreatedOn = DateTime.Now;
        private string _ModifiedBy = string.Empty;

        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set 
            {
                _ModifiedBy = value ?? throw new ArgumentNullException(nameof(ModifiedBy));
            }
        }
        private DateTime _ModifiedOn = DateTime.Now;

        public DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set 
            {
                if (value == null) throw new ArgumentNullException(nameof(ModifiedOn));
                _ModifiedOn = value;
            }
        }

    }
}
