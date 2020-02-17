export class MyLyricsRequestModel {
    constructor(public page: number = 1, public pageSize: number = 10, public includeCount: boolean = false) {}
}