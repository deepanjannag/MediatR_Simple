using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Test_Vehicle.Data;
using Test_Vehicle.Models;

namespace Test_Vehicle
{
    public class AddVehicle
    {
        public class Command: IRequest<Guid>
        {
            public int Year { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
        }

        public class CommandHandler: IRequestHandler<Command, Guid>
        {
            private IVehicleData _vehicleData;
            public CommandHandler(IVehicleData vehicleData)
            {
                _vehicleData = vehicleData;
            }

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Vehicle { Make=request.Make, Model=request.Model, Year=request.Year};
                await Task.Run(()=>_vehicleData.AddVehicle(entity));

                return entity.Id;
            }
        }
    }
}
