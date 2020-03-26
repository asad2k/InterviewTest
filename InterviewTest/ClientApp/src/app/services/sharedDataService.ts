import { Injectable } from '@angular/core';
import { PersonViewModel } from 'src/app/models/personViewModel';

@Injectable({
    providedIn: 'root'
})
export class SharedDataService {
    constructor() 
    { }

    public personSearchResult: Array<PersonViewModel>;
}