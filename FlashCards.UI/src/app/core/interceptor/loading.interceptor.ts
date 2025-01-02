import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { identity, delay, finalize } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { BusyService } from '../services/busy/busy.service';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const busyService = inject(BusyService);

  busyService.busy();

  return next(req).pipe(
    environment.isProduction ? identity : delay(500),
    finalize(() => busyService.idle())
  );
};
