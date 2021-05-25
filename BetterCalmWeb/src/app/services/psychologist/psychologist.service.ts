import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';

@Injectable({
    providedIn: 'root'
})
export class PsychologistService {
    private uri = environment.baseURL + 'psychologists';
    constructor(private http: HttpClient) { }

    add(body): Observable<PsychologistBasicInfo> {
        const headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': localStorage.getItem('token')
        });
        let options = { headers: headers };
        var httpRequest = this.http.post<PsychologistBasicInfo>(this.uri, body, options)
        .pipe(catchError(this.handleError));
        return httpRequest;
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}