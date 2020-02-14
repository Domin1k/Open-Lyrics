import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';


export class TokenInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const idToken = localStorage.getItem("id_token");
        let cloned = req;
        if (idToken) {
            cloned = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + idToken)
            }); 
        }
        
        return next.handle(cloned);
    }
}