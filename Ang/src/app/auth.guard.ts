import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, Route, UrlSegment } from '@angular/router';
import { Observable } from 'rxjs';
import {AppComponent} from './app.component';
import * as alertify from 'alertifyjs';
import { pathToFileURL } from 'url';
import { ToursComponent } from './tours/tours.component';
import { HotelsComponent } from './hotels/hotels.component';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {


  constructor(private router: Router) { }



  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let url: string = state.url;
    return this.checkUserLogin(route, url);
  }

  checkUserLogin(route: ActivatedRouteSnapshot, url: any): boolean {
    if (localStorage.getItem('Users')) {
      const userRole = localStorage.getItem('Roles').replace(/"/g, "");
      if (route.data.role && route.data.role.indexOf(userRole) === -1) {
        alertify.error("Access is denied!");
        this.router.navigate(['']); // переводит на хоум если роль не подошла
        return false;
      }
      return true;
    }
    if(localStorage.getItem('Users')==null){
      console.log("has not user");
      if(route.component==ToursComponent || route.component==HotelsComponent)
      { // если пользователь незареган, то ему доступен просмотр туров и отеле и регистрация
        return true;
      }

    }

    alertify.error("Access is denied!");
    this.router.navigate(['']); // переводит на хоум если пользоателя нет
    return false;
  }

  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.canActivate(next, state);
  }
  canDeactivate(
    component: unknown,
    currentRoute: ActivatedRouteSnapshot,
    currentState: RouterStateSnapshot,
    nextState?: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }








}
