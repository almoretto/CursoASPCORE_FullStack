// The line bellow is the same as using in C#
import { Event } from './Event';
import { SocialMedia } from './SocialMedia';

export interface Speaker {
    id: number;
    name: string;
    shortResume: string;
    imageUrl: string;
    phone: string;
    email: string;
    socialMedias: SocialMedia[];
    speakersEvents: Event[];
}
