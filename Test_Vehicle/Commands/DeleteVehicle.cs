using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Test_Vehicle.Data;

namespace Test_Vehicle.Commands
{
    public class DeleteVehicle
    {
        public class Command: IRequest
        {
            public Guid Id { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private IVehicleData _vehicleData;
            public CommandHandler(IVehicleData vehicleData)
            {
                _vehicleData = vehicleData;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = await Task.Run(() => request.Id);
                if (vehicle == null) return Unit.Value;

                _vehicleData.DeleteVehicle(_vehicleData.GetVehicles(vehicle));

                return Unit.Value;
            }
        }
    }
}
