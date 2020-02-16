using System.Collections.Generic;

namespace Application.UseCases.Lyrics.GetAll
{
    public interface IAllLyricsOutputHandler<T>
    {
        T Result();

        void Success(AllLyricsOutput output);

        void BadRequest(string msg);

    }
}
