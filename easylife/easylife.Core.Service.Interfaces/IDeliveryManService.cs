using easylife.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easylife.Core.Service.Interfaces
{
    public interface IDeliveryManService
    {
        IEnumerable<Delivery_Man> GetAll();
        IEnumerable<Delivery_Man> GetById(int Delivery_Man_id);
        bool Insert(Delivery_Man delivery_Man);
        bool Update(Delivery_Man delivery_Man);
        bool Delete(int Delivery_Man_id);

        IEnumerable<Delivery_Man> GetByMemberId(int Member_id);
        IEnumerable<Delivery_Man> GetByAvailability();
        IEnumerable<Delivery_Man> GetByUnavailability();

    }
}
