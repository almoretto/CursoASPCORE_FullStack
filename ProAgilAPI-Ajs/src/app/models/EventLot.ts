export interface EventLot {
    id: number;
    lotDescription: string;
    price: number;
    startDate?: Date;
    endDate?: Date;
    forSaleQty: number;
    eventId: number;
}
