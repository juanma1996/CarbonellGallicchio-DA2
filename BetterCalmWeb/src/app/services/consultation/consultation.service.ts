import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PsychologistBasicInfo } from 'src/app/models/psychologist/psychologist-basic-info';
import { BaseService } from '../base.service';




@Injectable({
    providedIn: 'root'
})
export class ConsultationService extends BaseService {
    private uri = environment.baseURL + 'consultations';

    constructor(private http: HttpClient) {
        super();
    }

    add(body): Observable<PsychologistBasicInfo> {
        let options = { headers: this.headers };
        var httpRequest = this.http.post<PsychologistBasicInfo>(this.uri, body, options)
            .pipe(catchError(this.handleError));
        return httpRequest;
    }
}