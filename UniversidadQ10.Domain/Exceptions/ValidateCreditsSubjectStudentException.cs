namespace UniversidadQ10.Domain.Exceptions
{
    public class ValidateCreditsSubjectStudentException: CoreBusinessException
    {
        public ValidateCreditsSubjectStudentException()
        {
        }

        public ValidateCreditsSubjectStudentException(string msg) : base(msg)
        {
        }

        public ValidateCreditsSubjectStudentException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
