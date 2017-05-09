import { CanActivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { TokenService } from './TokenService';

@Injectable()
export class AdminRouteGuard implements CanActivate {

  constructor(private authService: TokenService) {}

  canActivate() {
    return this.authService.getRoles();
  }
}
