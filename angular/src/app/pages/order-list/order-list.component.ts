import { Component } from '@angular/core';
import { InvitedCardComponent } from '../../components/Order-list/invited-card/invited-card.component';
import { AcceptedCardComponent } from '../../components/Order-list/accepted-card/accepted-card.component';
import { OrderService } from '../../services/order.service';
import { StatusOrdersEnum } from '../../enums/status-orders.enum';
import OrderDTO from '../../model/IOrderDTO';

@Component({
  selector: 'app-order-list',
  imports: [
    InvitedCardComponent,
    AcceptedCardComponent
  ],
  templateUrl: './order-list.component.html',
  styleUrl: './order-list.component.css'
})
export class OrderListComponent {
  invitedOrders: OrderDTO[] = [];
  acceptedOrders: OrderDTO[] = [];

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.loadOrders();
  }

  loadOrders(): void {
    this.orderService.getOrdersByStatus(StatusOrdersEnum.PENDENTE).subscribe((orders) => {
      this.invitedOrders = orders;
    });

    this.orderService.getOrdersByStatus(StatusOrdersEnum.APROVADO).subscribe((orders) => {
      this.acceptedOrders = orders;
    });
  }

  changeStatus(orderId: string, newStatus: StatusOrdersEnum): void {
    this.orderService.changeOrderStatus(orderId, newStatus).subscribe(() => {
      this.loadOrders(); 
    });
  }

}
