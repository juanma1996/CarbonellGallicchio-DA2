import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { CategoryBasicInfo } from 'src/app/models/category/category-basic-info';
import { PlaylistBasicInfo } from 'src/app/models/playlist/playlist-basic-info';
import { BaseService } from '../base.service';

@Injectable({
    providedIn: 'root'
})
export class PlaylistsService extends BaseService {
    private uri = environment.baseURL + 'playlists';

    constructor(private http: HttpClient) {
        super();
    }

    get(): Observable<[PlaylistBasicInfo]> {
        return this.http.get<[PlaylistBasicInfo]>(this.uri)
            .pipe(catchError(this.handleError));
    }
}