import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { CategoriesDashboardComponent } from '../../pages/categories/categories-dashboard/categories-dashboard.component';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { PlaylistBasicInfo } from 'src/app/models/playlist/playlist-basic-info';

@Injectable({
    providedIn: 'root'
})
export class CategoriesService {
    private uri = environment.baseURL + 'categories';
    constructor(private http: HttpClient) { }

    get(): Observable<[CategoryBasicInfo]> {
        return this.http.get<[CategoryBasicInfo]>(this.uri)
            .pipe(catchError(this.handleError));
    }

    getPlaylistByCategory(id): Observable<[PlaylistBasicInfo]> {
        return this.http.get<[PlaylistBasicInfo]>(this.uri+ '/' + id + '/playlists')
            .pipe(catchError(this.handleError));
    }

    private handleError(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}