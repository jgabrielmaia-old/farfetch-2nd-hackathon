import React, {useState} from 'react';
import { ImageBackground, View } from 'react-native';
import { Layout, Text, ViewPager} from '@ui-kitten/components';

import styles from './ImagesViewer.styles';

const ImagesViewer = ({images = [], question = ''}) => {
    const [selectedIndex, setSelectedIndex] = useState(0);

    const renderImage = (uri) => (
        <Layout key={uri} level='2' style={styles.view}>            
            <View style={styles.container}>
                <ImageBackground source={{uri}} style={styles.image}>
                    <Text style={styles.text}>{question}</Text>
                </ImageBackground>
            </View>
        </Layout>
    );


    return (
        <ViewPager selectedIndex={selectedIndex} onSelect={setSelectedIndex}>
            {images.map(renderImage)}
        </ViewPager>
    );
};

export default ImagesViewer;