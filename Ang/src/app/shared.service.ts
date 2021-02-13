import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Tour} from './tours/tour.module'

@Injectable({
  providedIn: 'root'
})
export class SharedService {

public readonly APIUrl: string ="https://localhost:44335/api";
public readonly PhotoUrl  ="https://localhost:44335/Photos/";
tour1: Tour;
  constructor(private http:HttpClient) {


  }

getTours():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+'/tours');
}

async getTour(id: number):Promise<any> {
    return this.http.get(this.APIUrl + '/tours/'+ id).toPromise();
}


PostTour(val:any) {
    return this.http.post(this.APIUrl+'/tours',val);
}

updateTour1(val: any) {
    return this.http.put(this.APIUrl+'/tours/'+val.id,val);
}
deleteTour(id: number) {
    return this.http.delete(this.APIUrl+'/tours/'+id);
}

PostUser(val:any){
  return this.http.post(this.APIUrl+'/users',val);
}


UploadPhoto(val:any){
  return this.http.post(this.APIUrl+'/tours/SaveFile',val);

}


// getUser(id: number){
//   return this.http.get(this.APIUrl + '/Users/'+ id);
// }

async GetUsersByLogin(login:string):Promise<any> {
  return this.http.get(this.APIUrl+'/Users/'+login).toPromise();
}



async getUsers():Promise<any[]> {
  return this.http.get<any>(this.APIUrl+'/Users').toPromise();
}


DeleteUsers(id:number){

  return this.http.delete(this.APIUrl+'/Users/'+id);

}


updateUser(val: any) {
  return this.http.put(this.APIUrl+'/users/'+val.id,val);
}

/////////////////////////////////////////////////////


getHotels(id:number, check:boolean):Observable<any[]> {
  return this.http.get<any>(this.APIUrl + '/hotels?TourId='+id+'&check='+check);
}
// https://localhost:44335/api/Hotels?TourId=1&check=false

//////////////////////////////////////////////////////

async GetHotel(id:number):Promise<any> {
  return this.http.get(this.APIUrl + '/Hotels/'+ id).toPromise();
}




deleteHotel(id: number) {
  return this.http.delete(this.APIUrl+'/hotels/'+id);
}

PostHotels(val:any) {
  return this.http.post(this.APIUrl+'/hotels',val);
}

PutHotels(val: any) {
  return this.http.put(this.APIUrl+'/hotels/'+val.id,val);
}

PostUserData(val:any){

  return this.http.post(this.APIUrl+'/UserDatas',val);
}

PutUserData(val:any){
  return this.http.put(this.APIUrl+'/UserDatas/'+val.id,val);
}



async GetuserData(id:number):Promise<any>{
  return this.http.get(this.APIUrl + '/UserDatas/'+ id).toPromise();;
}



GethotelRoom():Observable<any[]> {
  return this.http.get<any>(this.APIUrl + '/HotelRooms');

}




///////////////////////////////////////////////////////
GetroomNumber(id:number):Observable<any[]> {
  return this.http.get<any>(this.APIUrl + '/RoomNumbers?HotelId='+id);
}

async GetAllRooms():Promise<any[]> {
  return this.http.get<any>(this.APIUrl + '/RoomNumbers').toPromise();
}


PutRoomNumber(val:any){
  return this.http.put(this.APIUrl+'/RoomNumbers/'+val.id,val);
}

PostRoom(val:any){
  return this.http.post(this.APIUrl+'/RoomNumbers',val);
}

deleteRoom(id:number) {
  return this.http.delete(this.APIUrl+'/RoomNumbers/'+id);
}
////////////////////////////////////////////////////




Getcity_From():Observable<any[]> {
  return this.http.get<any>(this.APIUrl + '/City_From');

}

GetAirLines():Observable<any[]> {
  return this.http.get<any>(this.APIUrl + '/AirLines');

}

PostAirLines(val:any){
  return this.http.post(this.APIUrl+'/AirLines',val);
}

PutAirLines(val:any){
  return this.http.put(this.APIUrl+'/AirLines/'+val.id,val);
}


async GetAllAirLines():Promise<any[]> {
  return this.http.get<any>(this.APIUrl + '/AirLines').toPromise();

}

GetairCompany():Observable<any[]>{

  return this.http.get<any>(this.APIUrl + '/AirCompanies');
}

async GetAirComp():Promise<any[]>{

  return this.http.get<any>(this.APIUrl + '/AirCompanies').toPromise();
}


DeleteFlight(id:number){

  return this.http.delete(this.APIUrl+'/AirLines/'+id);

}


GetcityLanding() {
  return this.http.get(this.APIUrl + '/CityLandings');

}

async GetCityLand():Promise<any[]> {
  return this.http.get<any>(this.APIUrl + '/CityLandings').toPromise();

}




PostBooking(val:any){

  return this.http.post(this.APIUrl+'/Bookings',val);
}

DeleteBooking(id:number){

  return this.http.delete(this.APIUrl+'/Bookings/'+id);

}

async GetBooking(val:number):Promise<any> {
  return this.http.get(this.APIUrl + '/Bookings/'+val).toPromise();

}

PutBooking(val:any){
  return this.http.put(this.APIUrl+'/Bookings/'+val.id,val);
}

async GetAllBookings():Promise<any[]> {
  return this.http.get<any>(this.APIUrl+'/Bookings').toPromise();
}


async GetRoles():Promise<any[]> {
  return this.http.get<any>(this.APIUrl+'/Roles').toPromise();
}

}



