// <copyright file="Moves.cs" company="Jonathan le Grange">
//     Moves file for Zugszwang chess engine
// </copyright>

namespace Zugzwang
{
    using System;

    /// <summary>
    /// Class that calculates all valid moves
    /// </summary>
    public class Moves
    {
        ulong WhiteKingValid;
        ulong BlackKingValid;
        ulong WhiteKnightValid;
        ulong BlackKnightValid;
        ulong WhitePawnValid;
        ulong BlackPawnValid;
        // const ulong  MASK_FILE_H = 0x80808080808080; my one

        /// <summary>
        /// Bitboard of the H file
        /// </summary>
        public const ulong MaskFileH = 0x7F7F7F7F7F7F7F7F; // other guys one

        /// <summary>
        /// Bitboard of the A file
        /// </summary>
        public const ulong MaskFileA = 0xFEFEFEFEFEFEFEFE;

        /// <summary>
        /// Bitboard of the B file
        /// </summary>
        public const ulong MaskFileB = 0xFDFDFDFDFDFDFDFD;

        /// <summary>
        /// Bitboard of the G file
        /// </summary>
        public const ulong MaskFileG = 0xBFBFBFBFBFBFBFBF;

        /// <summary>
        /// Check of if En Passant is possible
        /// </summary>
        private bool isEnPassant = false;

        // ulong Occupied;
        // ulong Empty;

        /// <summary>
        /// Computes the valid movements of a white pawn
        /// </summary>
        /// <param name="whitePawnLocation">Location of white pawn to compute</param>
        /// <param name="allPieces">Bitboard of all pieces</param>
        /// <param name="allBlackPieces">Bitboard of all black pieces</param>
        /// <returns>The valid moves of the white pawn</returns>
        public ulong ComputeWhitePawns(ulong whitePawnLocation, ulong allPieces, ulong allBlackPieces)
        {
            // NEED TO ADD ENPASSANT CHECK
            // PROMOTIONS?
            if (this.isEnPassant == true)
            {
            }

            ulong whitePawnUpOne = (whitePawnLocation << 8) & ~allPieces;
            ulong whitePawnUpTwo = ((whitePawnLocation & BoardGeneration.InitialWhitePawns) << 16) & ~allPieces;

            ulong validPawnPushes = whitePawnUpOne | whitePawnUpTwo;

            ulong whitePawnLeftAttack = (whitePawnLocation & MaskFileA) << 7;
            ulong whitePawnRightAttack = (whitePawnLocation & MaskFileH) << 9;

            ulong validPawnAttacks = (whitePawnLeftAttack | whitePawnRightAttack) & allBlackPieces;

            ulong whitePawnValidMoves = validPawnPushes | validPawnAttacks;

            return whitePawnValidMoves;
        }

        /// <summary>
        /// Computes the valid moves of a black pawn
        /// </summary>
        /// <param name="blackPawnLocation">Location of the black pawn</param>
        /// <param name="allPieces">Bitboard detailing all pieces</param>
        /// <param name="allWhitePieces">Bitboard detailing all white pieces</param>
        /// <returns>All valid moves of the black pawn</returns>
        public ulong ComputeBlackPawns(ulong blackPawnLocation, ulong allPieces, ulong allWhitePieces)
        {
            // NEED TO ADD ENPASSANT CHECK
            // PROMOTIONS?
            ulong blackPawnUpOne = (blackPawnLocation >> 8) & ~allPieces;
            ulong blackPawnUpTwo = ((blackPawnLocation & BoardGeneration.InitialBlackPawns) >> 16) & ~allPieces;

            ulong blackPawnEnPassant = (blackPawnLocation)

            ulong validPawnPushes = blackPawnUpOne | blackPawnUpTwo;

            ulong blackPawnLeftAttack = (blackPawnLocation & MaskFileA) >> 7;
            ulong blackPawnRightAttack = (blackPawnLocation & MaskFileH) >> 9;

            ulong validPawnAttacks = (blackPawnLeftAttack | blackPawnRightAttack) & allWhitePieces;

            ulong blackPawnValidMoves = validPawnPushes | validPawnAttacks;

            return blackPawnValidMoves;
        }

        /// <summary>
        /// Computes all valid moves of a knight
        /// </summary>
        /// <param name="knightLocation">Position of knight</param>
        /// <param name="colour">Colour of knight</param>
        /// <returns>Valid moves the knight can make</returns>
        public ulong ComputeKnights(ulong knightLocation, string colour)
        {
            ulong ownPieces = 0;
            if (colour == "B")
            {
                ownPieces = BoardGeneration.BlackPieces;
            }

            if (colour == "W")
            {
                ownPieces = BoardGeneration.WhitePieces;
            }

            ulong moveOneClip = MaskFileA & MaskFileB;
            ulong moveTwoClip = MaskFileA;
            ulong moveThreeClip = MaskFileH;
            ulong moveFourClip = MaskFileH & MaskFileG;
            ulong moveFiveClip = MaskFileH & MaskFileG;
            ulong moveSixClip = MaskFileH;
            ulong moveSevenClip = MaskFileA;
            ulong moveEightClip = MaskFileA & MaskFileB;

            ulong knightMoveOne = (knightLocation & moveOneClip) << 6;
            ulong knightMoveTwo = (knightLocation & moveTwoClip) << 15;
            ulong knightMoveThree = (knightLocation & moveThreeClip) << 17;
            ulong knightMoveFour = (knightLocation & moveFourClip) << 10;
            ulong knightMoveFive = (knightLocation & moveFiveClip) >> 6;
            ulong knightMoveSix = (knightLocation & moveSixClip) >> 15;
            ulong knightMoveSeven = (knightLocation & moveSevenClip) >> 17;
            ulong knightMoveEight = (knightLocation & moveEightClip) >> 10;
            ulong validKnightMoves = knightMoveOne | knightMoveTwo | knightMoveThree | knightMoveFour | knightMoveFive | knightMoveSix | knightMoveSeven | knightMoveEight;

            return validKnightMoves & ~ownPieces;
        }

        /// <summary>
        /// Computes all valid moves of a king
        /// </summary>
        /// <param name="kingLocation">Location of king</param>
        /// <param name="colour">Colour of king</param>
        /// <returns>All valid moves of the king</returns>
        public ulong ComputeKing(ulong kingLocation, string colour)
        {
            ulong ownPieces = 0;
            if (colour == "B")
            {
                ownPieces = BoardGeneration.BlackPieces;
            }

            if (colour == "W")
            {
                ownPieces = BoardGeneration.WhitePieces;
            }

            ulong kingFileHClip = kingLocation & MaskFileH;
            ulong kingFileAClip = kingLocation & MaskFileA;

            ulong moveOne = kingFileHClip << 7;
            ulong moveTwo = kingLocation << 8;
            ulong moveThree = kingFileHClip << 9;
            ulong moveFour = kingFileHClip << 1;

            ulong moveFive = kingFileAClip >> 7;
            ulong moveSix = kingLocation >> 8;
            ulong moveSeven = kingFileAClip >> 9;
            ulong moveEight = kingFileAClip >> 1;

            ulong kingMoves = moveOne | moveTwo | moveThree | moveFour | moveFive | moveSix | moveSeven | moveEight;

            ulong validKingMoves = kingMoves & ~ownPieces;

            return validKingMoves;
        }

        /// <summary>
        /// Compute all valid moves a rook can make
        /// </summary>
        /// <param name="rookLocation">The position of the rook</param>
        /// <returns>All valid moves a rook can make</returns>
        public ulong ComputeRooks(ulong rookLocation, ulong allPieces)
        {
            // long binaryS = 1L << s;
            // ulong validHorizontalMoves = (Occupied - 2 * rookLocation) ^;
            ulong validRookMoves;

            // ulong validRookMoves = validHorizontalMoves | validVerticalMoves;
            

            // long possibilitiesHorizontal = (OCCUPIED - 2 * binaryS) ^ Long.reverse(Long.reverse(OCCUPIED) - 2 * Long.reverse(binaryS));
            // long possibilitiesVertical = ((OCCUPIED & FileMasks8[s % 8]) - (2 * binaryS)) ^ Long.reverse(Long.reverse(OCCUPIED & FileMasks8[s % 8]) - (2 * Long.reverse(binaryS)));
            // return (possibilitiesHorizontal & RankMasks8[s / 8]) | (possibilitiesVertical & FileMasks8[s % 8]);
            ulong validSouthAttacks = southAttacks(rookLocation, ~allPieces);
            ulong validNorthAttacks = northAttacks(rookLocation, ~allPieces);
            ulong validEastAttacks = eastAttacks(rookLocation, ~allPieces);
            ulong validWestAttacks = westAttacks(rookLocation, ~allPieces);

            validRookMoves = validSouthAttacks | validNorthAttacks | validEastAttacks | validWestAttacks;
            return validRookMoves;
        }

        public ulong ComputeBishops(ulong bishopLocation, ulong allPieces)
        {
            ulong validBishopMoves;

            ulong validNorthEastAttacks = northEastAttacks(bishopLocation, ~allPieces);
            ulong validNorthWestAttacks = northWestAttacks(bishopLocation, ~allPieces);
            ulong validSouthEastAttacks = southEastAttacks(bishopLocation, ~allPieces);
            ulong validSouthWestAttacks = southWestAttacks(bishopLocation, ~allPieces);

            validBishopMoves = validNorthEastAttacks | validNorthWestAttacks | validSouthEastAttacks | validSouthWestAttacks;

            return validBishopMoves;
        }

        public ulong ComputeQueens(ulong queenLocation, ulong allPieces)
        {
            ulong validQueenMoves;

            validQueenMoves = ComputeBishops(queenLocation, allPieces) | ComputeRooks (queenLocation, allPieces);

            return validQueenMoves;
        }

        public ulong southAttacks(ulong rooks, ulong empty)
        {
            ulong flood = rooks;
            flood |= rooks = (rooks >> 8) & empty;
            flood |= rooks = (rooks >> 8) & empty;
            flood |= rooks = (rooks >> 8) & empty;
            flood |= rooks = (rooks >> 8) & empty;
            flood |= rooks = (rooks >> 8) & empty;
            flood |= (rooks >> 8) & empty;

            ulong validSouthMoves = flood >> 8;
            return validSouthMoves;
        }

        public ulong northAttacks(ulong rooks, ulong empty)
        {
            ulong flood = rooks;
            flood |= rooks = (rooks << 8) & empty;
            flood |= rooks = (rooks << 8) & empty;
            flood |= rooks = (rooks << 8) & empty;
            flood |= rooks = (rooks << 8) & empty;
            flood |= rooks = (rooks << 8) & empty;
            flood |= (rooks << 8) & empty;

            ulong validNorthMoves = flood << 8;
            return validNorthMoves;
        }

        public ulong eastAttacks(ulong rooks, ulong empty)
        {
            ulong flood = rooks;
            empty &= MaskFileA;
            flood |= rooks = (rooks << 1) & empty;
            flood |= rooks = (rooks << 1) & empty;
            flood |= rooks = (rooks << 1) & empty;
            flood |= rooks = (rooks << 1) & empty;
            flood |= rooks = (rooks << 1) & empty;
            flood |= (rooks << 1) & empty;

            ulong validEastMoves = (flood << 1) & MaskFileA;
            return validEastMoves;
        }

        public ulong westAttacks(ulong rooks, ulong empty)
        {
            ulong flood = rooks;
            empty &= MaskFileH;
            flood |= rooks = (rooks >> 1) & empty;
            flood |= rooks = (rooks >> 1) & empty;
            flood |= rooks = (rooks >> 1) & empty;
            flood |= rooks = (rooks >> 1) & empty;
            flood |= rooks = (rooks >> 1) & empty;
            flood |= (rooks >> 1) & empty;

            ulong validWestMoves = (flood >> 1) & MaskFileH;
            return validWestMoves;
        }

        public ulong northEastAttacks (ulong bishops, ulong empty)
        {
            ulong flood = bishops;
            empty &= MaskFileA;
            flood |= bishops = (bishops << 9) & empty;
            flood |= bishops = (bishops << 9) & empty;
            flood |= bishops = (bishops << 9) & empty;
            flood |= bishops = (bishops << 9) & empty;
            flood |= bishops = (bishops << 9) & empty;
            flood |= (bishops << 9) & empty;

            ulong validNorthEastAttacks =  (flood << 9) & MaskFileA;
            return validNorthEastAttacks;
        }

        public ulong southEastAttacks (ulong bishops, ulong empty)
        {
            ulong flood = bishops;
            empty &= MaskFileA;

            flood |= bishops = (bishops >> 7) & empty;
            flood |= bishops = (bishops >> 7) & empty;
            flood |= bishops = (bishops >> 7) & empty;
            flood |= bishops = (bishops >> 7) & empty;
            flood |= bishops = (bishops >> 7) & empty;
            flood |= (bishops >> 7) & empty;

            ulong validSouthEastAttacks = (flood >> 7) & MaskFileA;
            return validSouthEastAttacks;
        }

        public ulong northWestAttacks(ulong bishops, ulong empty)
        {
            ulong flood = bishops;
            empty &= MaskFileH;
            flood |= bishops = (bishops << 7) & empty;
            flood |= bishops = (bishops << 7) & empty;
            flood |= bishops = (bishops << 7) & empty;
            flood |= bishops = (bishops << 7) & empty;
            flood |= bishops = (bishops << 7) & empty;
            flood |= (bishops << 7) & empty;

            ulong validNorthWestAttacks = (flood << 7) & MaskFileH;
            return validNorthWestAttacks;
        }

        public ulong southWestAttacks (ulong bishops, ulong empty)
        {
            ulong flood = bishops;
            empty &= MaskFileH;
            flood |= bishops = (bishops >> 9) & empty;
            flood |= bishops = (bishops >> 9) & empty;
            flood |= bishops = (bishops >> 9) & empty;
            flood |= bishops = (bishops >> 9) & empty;
            flood |= bishops = (bishops >> 9) & empty;
            flood |= (bishops >> 9) & empty;

            ulong validSouthWestAttacks = (flood >> 9) & MaskFileH;
            return validSouthWestAttacks;
        }
    }
}
