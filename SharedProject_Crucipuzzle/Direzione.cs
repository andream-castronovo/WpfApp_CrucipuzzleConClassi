using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject_Crucipuzzle
{
    public enum Direzione : byte
    {
        NULL,        // Nessuna direzione
        Dx_Sx,       // << Da destra a sinistra <<
        Sx_Dx,       // >> Da sinistra a destra >>
        Up_Down,     // ∨∨ Da sopra a sotto ∨∨
        Down_Up,     // ∧∧ Da sotto a sopra ∧∧
        UpSx_DownDx, // Diagonale verso il basso da sinistra a destra 
        DownDx_UpSx, // Diagonale verso l'alto da destra verso sinistra
        UpDx_DownSx, // Diagonale verso il basso da destra verso sinistra
        DownSx_UpDx, // Diagnoale verso l'alto da sinistra verso destra
    }
}
