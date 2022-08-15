using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Test_Vehicle.Data;
using Test_Vehicle.Models;

namespace Test_Vehicle
{
    public class GetVehicle
    {
        public class Query : IRequest<Vehicle>
        {
            public Guid Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Vehicle>
        {
            private IVehicleData _vehicleData;
            public QueryHandler(IVehicleData vehicleData)
            {
                _vehicleData = vehicleData;
            }

            public async Task<Vehicle> Handle(Query request, CancellationToken cancellationToken)
            {
                return await Task.Run(() => _vehicleData.GetVehicles(request.Id));                
            }
        }
    }
}
