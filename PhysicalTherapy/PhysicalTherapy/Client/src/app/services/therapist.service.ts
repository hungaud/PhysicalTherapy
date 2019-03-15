import { apiEndpoint } from '../globals'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Therapist } from '../models/Therapist';

@Injectable()
export class TherapistService {
    private headers: HttpHeaders;
    private accessPointUrl: string = `${apiEndpoint}/Therapists`;

    constructor(private http: HttpClient) {
        this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
    }

    public getAll() : Observable<Therapist[]> {
        return this.http.get<Therapist[]>(this.accessPointUrl);
    }

    public getTherapistByUsername(username) : Observable<Therapist> {
        return this.http.get<Therapist>(`${this.accessPointUrl}/${username}`);
    }
}

