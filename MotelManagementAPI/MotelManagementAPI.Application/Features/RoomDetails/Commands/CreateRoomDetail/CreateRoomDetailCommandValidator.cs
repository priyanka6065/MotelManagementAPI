using MotelManagementAPI.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Application.Features.RoomDetails.Commands.CreateRoomDetail
{
    public class CreateRoomDetailCommandValidator : AbstractValidator<CreateRoomDetailCommand>
    {
        private readonly IRoomDetailsRepositoryAsync roomDetailRepository;

        public CreateRoomDetailCommandValidator(IRoomDetailsRepositoryAsync roomDetailRepository)
        {
            this.roomDetailRepository = roomDetailRepository;

            RuleFor(p => p.RoomNo)
                .NotEmpty().WithMessage("{RoomNo} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{RoomNo} must not exceed 5 characters.")
                .MustAsync(IsRoomNoUniqueAsync).WithMessage("{RoomNo} already exists.");

            RuleFor(p => p.NoOfBed)
                //.NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{NoOfBed} is required.");
            //.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        private async Task<bool> IsRoomNoUniqueAsync(string roomNo, CancellationToken cancellationToken)
        {
            return await roomDetailRepository.IsRoomNoUniqueAsync(roomNo);
        }
    }
}
