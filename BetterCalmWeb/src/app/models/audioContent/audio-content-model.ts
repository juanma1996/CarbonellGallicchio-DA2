import { PlaylistBasicInfo } from '../playlist/playlist-basic-info';
import { CategoryModel } from '../category/category-model';
import { PlaylistModel } from '../playlist/playlist-model';

export class AudioContentModel {
    name: string;
    duration: string // Temporary until we know how to threat timeSpan.
    creatorName: string;
    imageUrl: string;
    audioUrl: string;
    categories: CategoryModel[];
    playlists: PlaylistBasicInfo[];
}
