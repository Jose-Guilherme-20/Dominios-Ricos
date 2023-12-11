namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscription;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();

            if (firstName.Length == 0)
            {
                throw new Exception("Nome inválido");
            }
        }

        public string FirstName { get; private set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            // Se já tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinaturas, e coloca esta
            // como principal
            foreach (var sub in Subscriptions)
            {
                sub.Inactivate();
                _subscription.Add(subscription);
            }
        }
    }
}