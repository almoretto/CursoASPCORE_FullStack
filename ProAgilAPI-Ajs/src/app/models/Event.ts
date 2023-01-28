import { EventLot } from './EventLot';
import { SocialMedia } from './SocialMedia';
import { Speaker } from './Speaker';

export interface Event {
    // use lower case on variable name because the angular return is on lCase. 
    id: number; // equals int in C#
    local: string;
    eventDate: Date; // equals DateTime in C#
    subject: string;
    guestsQty: number;
    phone: string;
    email: string;
    imageURL: string;
    lots: EventLot[];
    socialMedias: SocialMedia[];
    speakersEvents: Speaker[];

}
