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
        IEnumerable<DeliveryMan> GetAll();
        DeliveryMan GetById(int DeliveryManId);
        bool Insert(DeliveryMan deliveryMan);
        bool Update(DeliveryMan deliveryMan);
        bool Delete(int DeliveryManId);

        IEnumerable<DeliveryMan> GetByMemberId(int MemberId);
        IEnumerable<DeliveryMan> GetByAvailability();
        IEnumerable<DeliveryMan> GetByUnavailability();

    }
}
