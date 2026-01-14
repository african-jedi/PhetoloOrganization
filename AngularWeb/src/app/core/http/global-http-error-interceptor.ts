import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError, retry, throwError } from 'rxjs';
import { inject } from '@angular/core';

export const globalHttpErrorInterceptor: HttpInterceptorFn = (req, next) => {
  const snackBar=inject(MatSnackBar);

  return next(req).pipe(
    retry({ count: 3, delay: 500 }),
    catchError((error: HttpErrorResponse) => {
      snackBar.open('Failed to connect to external resource', 'close',{
        duration: 5000,
        panelClass: ["error-snackbar"]
      });
      return throwError(() => error);
    })
  );
};
