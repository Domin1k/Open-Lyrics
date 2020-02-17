import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpConfigInterceptor implements HttpInterceptor {
    constructor(private snackBar: MatSnackBar) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const idToken = localStorage.getItem("id_token");
        let cloned = req;
        if (idToken) {
            cloned = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + idToken)
            });
        }

        if (!cloned.headers.has('Content-Type')) {
            cloned = cloned.clone({ headers: cloned.headers.set('Content-Type', 'application/json') });
        }

        cloned = cloned.clone({ headers: cloned.headers.set('Accept', 'application/json') });


        return next.handle(cloned).pipe(
            map((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    console.debug('event--->>>', event);
                }
                return event;
            }),
            catchError((error: HttpErrorResponse) => {
                const data = {
                    reason: error.statusText,
                    status: error.status
                };
                console.error(error.message)
                this.snackBar.open(
                    data.reason,
                    data.status.toString(),
                    {
                        duration: 2000,
                        verticalPosition: 'top',
                        horizontalPosition: 'center'
                    });
                return throwError(error);
            }));
    }
}