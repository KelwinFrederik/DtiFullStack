import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import OrderDTO from '../model/IOrderDTO';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'https://localhost:7038/api/orders'; // Ajuste para a URL da sua API
  
  constructor(private http: HttpClient) {}

  getOrdersByStatus(status: number): Observable<OrderDTO[]> {
    return this.http.get<OrderDTO[]>(`${this.apiUrl}?status=${status}`);
  }

  changeOrderStatus(orderId: string, newStatus: number): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/status`, {orderId, newStatus });
  }
}
