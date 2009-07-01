﻿namespace ConsoleApplication23.Experimental
{
    using System.Collections.Generic;
    using System.Linq;

    using QI4N.Framework;

    public interface CustomerRepository
    {
        Customer FindByIdentity(string identity);

        Customer FindByName(string name);
    }

    [Mixins(typeof(CustomerRepositoryMixin))]
    public interface CustomerRepositoryService : CustomerRepository, ServiceComposite
    {
    }

    public class CustomerRepositoryMixin : CustomerRepository
    {
        [Structure]
        private UnitOfWorkFactory uowf;

        public Customer FindByIdentity([NotNull] string identity)
        {
            UnitOfWork uow = this.uowf.CurrentUnitOfWork;
            return uow.Find<Customer>(identity);
        }

        public Customer FindByName( [NotNull] string name)
        {
            UnitOfWork uow = this.uowf.CurrentUnitOfWork;

            IEnumerable<Customer> result = from customer in uow.NewQuery<Customer>()
                                           where customer.Name == name
                                           select customer;

            return result.FirstOrDefault();
        }
    }
}