using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            value.Rating = command.Rating;
            value.Title = command.Title;
            value.ReleaseDate = command.ReleaseDate;
            value.Duration = command.Duration;
            value.Status = command.Status;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Description = command.Description;
            value.CreatedYear = command.CreatedYear;
            await _context.SaveChangesAsync();
        }
    }
}
