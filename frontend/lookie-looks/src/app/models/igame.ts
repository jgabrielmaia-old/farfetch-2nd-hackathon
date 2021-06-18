import { IVote } from "./ivote";

export interface IGame {
    gameId:string,
    attributeId:string,
    isBallotOpen:string,
    attributeOptions:string[],
    imageLinks:string[],
    votes:IVote[]
}