using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Test_Vehicle.Data;
using Test_Vehicle.Models;

namespace Test_Vehicle
{
    public class GetVehicles
    {
        public class Query: IRequest<IEnumerable<Vehicle>>
        {

        }

        public class QueryHandler : IRequestHandler<Query, IEnumerable<Vehicle>>
        {
            private IVehicleData _vehicleData;            
            public QueryHandler(IVehicleData vehicleData)
            {
                _vehicleData = vehicleData;
            }

            public async Task<IEnumerable<Vehicle>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Task.Run(() => _vehicleData.GetVehicles());
                //return  _vehicleData.GetVehicles()
            }
        }
    }
}
