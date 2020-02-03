namespace Application.UseCases.Lyrics.Details
{
    using System.Collections.Generic;
    public interface IDetailsLyricsOutputHandler<T>
    {
        T Result();

        void Success(DetailsLyricsOutput output);

        void BadRequest(string msg);
    }
}
