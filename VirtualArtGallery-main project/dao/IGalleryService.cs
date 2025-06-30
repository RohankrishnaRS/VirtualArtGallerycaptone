using System.Collections.Generic;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.DAO
{
    public interface IGalleryService
    {
        // Gallery Management
        bool AddGallery(Gallery gallery);
        bool UpdateGallery(Gallery gallery);
        bool RemoveGallery(int galleryId);
        Gallery GetGalleryById(int galleryId);
        List<Gallery> SearchGalleries(string keyword);
    }
}
