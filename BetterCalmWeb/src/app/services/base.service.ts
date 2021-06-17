import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class BaseService {

    protected headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': localStorage.getItem('token')
    });

    protected handleError(error: HttpErrorResponse) {
        if (error.status == 0) {
            return throwError("Server problems, unexpected error");
        }
        else {
            return throwError(error.error);
        }
    }
}