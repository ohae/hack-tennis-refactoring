using System;

namespace Hack.Lib
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}
