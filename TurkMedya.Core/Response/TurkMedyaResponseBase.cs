using System;

namespace TurkMedya.Core.Response
{
    public abstract class TurkMedyaResponseBase<T>
    {
        public virtual int errorCode { get; set; }
        public virtual string errorMessage { get; set; }

        public virtual T data { get; set; }
    }
}
