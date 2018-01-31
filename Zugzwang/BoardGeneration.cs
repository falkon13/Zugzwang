// <copyright file="BoardGeneration.cs" company="Jonathan le Grange">
//     Board Generation file for Zugszwang chess engine
// </copyright>

namespace Zugzwang
{
    using System;

    /// <summary>
    /// Generates the initial board and the chess pieces position
    /// </summary>
    public class BoardGeneration
    {
        /// <summary>
        /// Bitboard detailing the initial placement of all white pawns
        /// </summary>
        public const ulong InitialWhitePawns = 0xFF00;

        /// <summary>
        /// Bitboard detailing the initial placement of all white rooks
        /// </summary>
        public const ulong InitialWhiteRooks = 0x81;

        /// <summary>
        /// Bitboard detailing the initial placement of all white bishops
        /// </summary>
        public const ulong InitialWhiteBishops = 0x24;

        /// <summary>
        /// Bitboard detailing the initial placement of all white knights
        /// </summary>
        public const ulong InitialWhiteKnights = 0x42;

        /// <summary>
        /// Bitboard detailing the initial placement of the white king
        /// </summary>
        public const ulong InitialWhiteKing = 0x10;

        /// <summary>
        /// Bitboard detailing the initial placement of all white queens
        /// </summary>
        public const ulong InitialWhiteQueens = 0x8;

        /// <summary>
        /// Bitboard detailing the initial placement of all black pawns
        /// </summary>
        public const ulong InitialBlackPawns = 0xFF000000000000;

        /// <summary>
        /// Bitboard detailing the initial placement of all black rooks
        /// </summary>
        public const ulong InitialBlackRooks = 0x8100000000000000;

        /// <summary>
        /// Bitboard detailing the initial placement of all black bishops
        /// </summary>
        public const ulong InitialBlackBishops = 0x2400000000000000;

        /// <summary>
        /// Bitboard detailing the initial placement of all black knights
        /// </summary>
        public const ulong InitialBlackKnights = 0x4200000000000000;

        /// <summary>
        /// Bitboard detailing the initial placement of the black king
        /// </summary>
        public const ulong InitialBlackKing = 0x1000000000000000;

        /// <summary>
        /// Bitboard detailing the initial placement of all black queens
        /// </summary>
        public const ulong InitialBlackQueens = 0x800000000000000;

        /// <summary>
        /// Bitboard detailing the initial placement of all white pieces
        /// </summary>
        public const ulong InitialWhitePieces = InitialWhitePawns | InitialWhiteRooks | InitialWhiteBishops | InitialWhiteKnights | InitialWhiteKing | InitialWhiteQueens;

        /// <summary>
        /// Bitboard detailing the initial placement of all black pieces
        /// </summary>
        public const ulong InitialBlackPieces = InitialBlackPawns | InitialBlackRooks | InitialBlackBishops | InitialBlackKnights | InitialBlackKing | InitialBlackQueens;

        /// <summary>
        /// Bitboard detailing the initial placement of pieces
        /// </summary>
        public const ulong InitialAllPieces = InitialBlackPieces | InitialWhitePieces;

        /// <summary>
        /// Bitboard detailing the position of all white pieces
        /// </summary>
        public static ulong WhitePieces;

        /// <summary>
        /// Bitboard detailing the position of all white pawns
        /// </summary>
        private static ulong whitePawns;

        /// <summary>
        /// Bitboard detailing the position of all white rooks
        /// </summary>
        private static ulong whiteRooks;

        /// <summary>
        /// Bitboard detailing the position of all white bishops
        /// </summary>
        private static ulong whiteBishops;

        /// <summary>
        /// Bitboard detailing the position of all white knights
        /// </summary>
        private static ulong whiteKnights;

        /// <summary>
        /// Bitboard detailing the position of the white king
        /// </summary>
        private static ulong whiteKing;

        /// <summary>
        /// Bitboard detailing the position of all white queens
        /// </summary>
        private static ulong whiteQueens;

        /// <summary>
        /// Bitboard detailing the position of all black pieces
        /// </summary>
        public static ulong BlackPieces;

        /// <summary>
        /// Bitboard detailing the position of all black pawns
        /// </summary>
        private static ulong blackPawns;

        /// <summary>
        /// Bitboard detailing the position of all black rooks
        /// </summary>
        private static ulong blackRooks;

        /// <summary>
        /// Bitboard detailing the position of all black bishops
        /// </summary>
        private static ulong blackBishops;

        /// <summary>
        /// Bitboard detailing the position of all black knights
        /// </summary>
        private static ulong blackKnights;

        /// <summary>
        /// Bitboard detailing the position of the black king
        /// </summary>
        private static ulong blackKing;

        /// <summary>
        /// Bitboard detailing the position of all black queens
        /// </summary>
        private static ulong blackQueens;

        /// <summary>
        /// Bitboard detailing the position of all pieces
        /// </summary>
        private static ulong allPieces;

        /// <summary>
        /// Place the initial pieces onto the board
        /// </summary>
        public static void InitateBoard()
        {
            WhitePieces = InitialWhitePieces;
            whitePawns = InitialWhitePawns;
            whiteRooks = InitialWhiteRooks;
            whiteBishops = InitialWhiteBishops;
            whiteKnights = InitialWhiteKnights;
            whiteKing = InitialWhiteKing;
            whiteQueens = InitialWhiteQueens;
            BlackPieces = InitialBlackPieces;
            blackPawns = InitialBlackPawns;
            blackRooks = InitialBlackRooks;
            blackBishops = InitialBlackBishops;
            blackKnights = InitialBlackKnights;
            blackKing = InitialBlackKing;
            blackQueens = InitialBlackQueens;
            allPieces = InitialAllPieces;
        }
    }
}