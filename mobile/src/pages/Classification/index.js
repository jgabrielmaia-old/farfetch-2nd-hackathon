import React from 'react';
import { StyleSheet, SafeAreaView } from 'react-native';
import { Divider, Layout, TopNavigation } from '@ui-kitten/components';
import ImagesViewer from '../../components/ImagesViewer/ImagesViewer';


export const ClassificationScreen = ({ navigation }) => {
  return (
    <SafeAreaView style={{ flex: 1 }}>
      <TopNavigation title='Lookie Looks' alignment='center'/>
      <Divider/>
      <Layout style={styles.layout}>
        <ImagesViewer images={[
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680739_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680741_1000.jpg", 
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32682754_1000.jpg",
          "https://cdn-images.farfetch-contents.com/16/68/76/35/16687635_32680740_1000.jpg"]} 
          question='what is the main color?'/>
      </Layout>
    </SafeAreaView>
  );
};


const styles = StyleSheet.create({
  layout : {
    flex: 1, 
    justifyContent: 'center', 
  }
});
