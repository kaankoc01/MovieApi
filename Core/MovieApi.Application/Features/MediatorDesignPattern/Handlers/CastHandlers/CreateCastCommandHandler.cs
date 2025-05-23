﻿using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;

        public CreateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _context.Casts.Add(new Cast
            {
                Name = request.Name,
                Title = request.Title,
                Surname = request.Surname,
                ImageUrl = request.ImageUrl,
                Overview = request.Overview,
                Biography = request.Biography
            });
            await _context.SaveChangesAsync();
        }
    }
}
