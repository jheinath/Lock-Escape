function scan() {
    import('./qr-scanner.min.js').then((module) => {
        const QrScanner = module.default;
        // do something with QrScanner
        const videoElem = document.getElementById('video');
        console.log('videoElem found')
        if (videoElem === null) return;
        const qrScanner = new QrScanner(
            videoElem,
            r => window.open(r.data, "_self"),
            {returnDetailedScanResult: true}
        );
        qrScanner.start()
    });
}